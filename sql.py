import re
import os
from typing import List, Tuple
from google.cloud import bigquery

# def read_query_from_file(filename: str) -> Tuple[str, List[str]]:
#     """Reads a SQL query and output fields from a file.

#     Args:
#         filename: A string containing the name of the file to read.

#     Returns:
#         A tuple containing the SQL query and a list of output field names.
#     """
#     with open(filename, "r") as file:
#         query = file.read().strip()

#     # Split the query into lines and remove empty lines and comments.
#     lines = [line.strip() for line in query.split("\n") if line.strip() and not line.strip().startswith("--")]

#     # Find the output fields by looking for the first SELECT statement.
#     output = []
#     for line in lines:
#         if line.startswith("SELECT"):
#             output = re.findall(r"\b\w+\b", line)[1:]
#             break

#     return query, output

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

    # Split the query into lines and remove empty lines and comments.
    lines = [line.strip() for line in query.split("\n") if line.strip() and not line.strip().startswith("--")]

    # Find the output fields by looking for the first SELECT statement.
    output = []
    for line in lines:
        if line.startswith("SELECT"):
            # Extract the output fields using a regular expression.
            fields = re.findall(r"(?i)\bAS\b\s+(\w+)|(?i)\b(\w+)\s*(,|$)", line)
            output = [field[0] or field[1] for field in fields]
            break

    return query, output

def run_query(query: str, output: List[str]) -> None:
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

        # Print the results.
        print("The query data:")
        print(",".join(str(field) for field in output))
        for row in query_job:
            print(", ".join(str(row[field]) for field in output))


if __name__ == "__main__":
    # filename = "states_with_most_distinct_names.txt"
    # query, output = read_query_from_file(filename)
    # run_query(query, output)

  

# Define the directory containing the SQL query files.
    directory = "/home/meenamakhijani1063/sql_queries"

# Loop over each file in the directory.
    for filename in os.listdir(directory):
    # Skip any files that are not .txt files.
        if not filename.endswith(".txt"):
            continue

    # Read the query and output fields from the file.
        query, output = read_query_from_file(os.path.join(directory, filename))

    # Run the query and print the results.
        run_query(query, output)
