variable "alert_policies" {
  type = map(object({
    display_name = string
    notification_channels = list(string)
    documentation_content = string
    condition_threshold = object({
      display_name = string
      comparison = string
      threshold_value = number
      duration = string
      filter = string
      aggregations = list(object({
        alignment_period = string
        per_series_aligner = string
        reduce_function = string
      }))
    })
    condition_monitoring_query_language = object({
      query = string
    })
  }))
  
  default = {}
}

resource "google_monitoring_alert_policy" "example" {
  for_each = var.alert_policies
  
  display_name = each.value.display_name
  
  combiner = "OR"
  
  conditions {
    display_name = each.value.condition_threshold.display_name
    
    condition_threshold {
      comparison = each.value.condition_threshold.comparison
      threshold_value = each.value.condition_threshold.threshold_value
      duration = each.value.condition_threshold.duration
      filter = each.value.condition_threshold.filter
      
      for_each = each.value.condition_threshold.aggregations
      
      aggregations {
        alignment_period = each.value.condition_threshold.aggregations.value.alignment_period
        per_series_aligner = each.value.condition_threshold.aggregations.value.per_series_aligner
        reduce_function = each.value.condition_threshold.aggregations.value.reduce_function
      }
    }
    
    condition_monitoring_query_language {
      query = each.value.condition_monitoring_query_language.query
    }
  }
  
  notification_channels = each.value.notification_channels
  
  documentation {
    content = each.value.documentation_content
  }
  
  project = var.project_id
}

alert_policies = {
    "example_policy_1" = {
      display_name = "Example Alert Policy 1"
      combiner = "OR"
      notification_channels = ["projects/my-project-id/notificationChannels/my-notification-channel-id"]
      documentation_content = "This is an example alert policy."
      condition_threshold = {
        display_name = "Example Threshold Condition"
        comparison = "COMPARISON_GT"
        threshold_value = 10
        duration = "60s"
        #filter = "metric.type=\"compute.googleapis.com/instance/cpu/utilization\" resource.type=\"gce_instance\" resource.label.\"instance_id\"=\"1234567890123456789\""
        aggregations = [
          {
            alignment_period = "60s"
            per_series_aligner = "ALIGN_MEAN"
          },
          {
            alignment_period = "300s"
            per_series_aligner = "ALIGN_MEAN"
          }
        ]
      }
      condition_monitoring_query_language = {
        query = "fetch gce_instance::compute.googleapis.com/instance/cpu/utilization | filter (resource.label.instance_id == '1234567890123456789') | window 5m | condition mean > 10"
        duration = "120s"
      }
    },
  }
