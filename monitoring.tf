resource "google_logging_metric" "set_iam_policy_metric" {
  name        = "set_iam_policy_metric"
  description = "Metric for SetIamPolicy audit logs"
  filter      = "protoPayload.methodName=\"SetIamPolicy\" AND protoPayload.serviceData.policyDelta.auditConfigDeltas:*"
  metric_descriptor {
    metric_kind = "DELTA"
    value_type  = "INT64"
    unit        = "1"
    description = "Number of SetIamPolicy audit logs"
    display_name = "SetIamPolicy Audit Logs"
  }
}

resource "google_monitoring_alert_policy" "set_iam_policy_alert_policy" {
  display_name = "SetIamPolicy Alert Policy"
  combiner     = "OR"

  conditions {
    display_name = "SetIamPolicy Condition"
    condition_threshold {
      filter           = "metric.type=\"logging.googleapis.com/user/${google_logging_metric.set_iam_policy_metric.name}\""
      duration         = "300s"
      comparison       = "COMPARISON_GT"
      threshold_value  = 1
      aggregation_cross_series_reducer = "REDUCE_COUNT"
      aggregation_per_series_aligner    = "ALIGN_SUM"
    }
  }

  notification_channels = ["${google_monitoring_notification_channel.slack_notification_channel.id}"]
}
