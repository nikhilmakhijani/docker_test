import re
import os
from typing import List, Tuple
from google.cloud import bigquery
import yaml
import re
from typing import List, Tuple

def read_query_from_file(filename: str) -> Tuple[str, List[str]]:
    """Reads a SQL query and output fields from a file.

    Args:
        filename: A string containing the name of the file to read.

    Returns:
        A tuple containing the SQL query and a list of output field names.
    """
    with open(filename, "r") as file:
        query = file.read().strip()

    return query

def run_query(query: str) -> None:
    """Runs a BigQuery SQL query and prints the results.

    Args:
        query: A string containing a valid BigQuery SQL query.
        output: A list of strings indicating the names of the columns to print.

    Returns:
        None.
    """
    # Create a BigQuery client object.
    with bigquery.Client() as client:
        # Run the query.
        query_job = client.query(query)
        results = query_job.result()

        # Print the results.
        print("The query data:")
        for row in results:
            print(row)



if __name__ == "__main__":

# Define the directory containing the SQL query files.
    directory = "/home/meenamakhijani1063/sql_queries"
    for filename in os.listdir(directory):
    # Skip any files that are not .txt files.
        if not filename.endswith(".txt"):
            continue

    # Read the query and output fields from the file.
        query = read_query_from_file(os.path.join(directory, filename))

    # Run the query and print the results.
        run_query(query)
