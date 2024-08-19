TestRun Processor

Overview

The TestRun Analyzer is a C# application designed to process test run data stored in JSON format. The application extracts statistics from the JSON data and exports the results to a CSV file. This tool is useful for analyzing automated test run results and gaining insights into test performance metrics.


Features

JSON Deserialization: The application deserializes a JSON file containing test run data.
Statistics Extraction: It calculates various statistics, such as the total number of tests run, the number of tests that passed or failed, the total run duration, average test duration, maximum, and minimum test durations.
CSV Export: The extracted statistics, along with individual test data, are exported to a CSV file for further analysis.

Getting Started

Prerequisites
.NET SDK (version 6.0 or later)
Visual Studio Code or any C# IDE
Git (for version control)

Installation

Clone the Repository:
git clone https://github.com/araujoanderson/TestRunAnalizer.git
cd TestRunProcessor

Install Dependencies:

Ensure you have the necessary NuGet packages installed. You can install them via Visual Studio or by running:
dotnet restore

Build the Solution:
dotnet build


Usage
Provide the JSON File Path:

When prompted, provide the path to the folder containing the JSON file that contains the test run data(The file must be called testRun.json, non case sensitive). If no path is provided, a default path will be used(Default path will be the root directory where the .exe is, there might be a default testRun.json file there replace it with your own if neeeded).

CSV Output:

The application will output a CSV file containing the extracted statistics and test data. This file will be saved in the same directory as the JSON file or in the project's root directory if no path is provided.


The JSON format used is as follows(See provided testRun.json file for reference):

 {
    "id": 1,
    "totalRunDuration": "PT1H25M33S",
    "totalTestCount": 4,
    "ExecutionDate": "02/28/24",
    "tests": [
      {
        "title": "Login with correct user",
        "id": 1,
        "result": "passed",
        "duration": "PT2M45S",
        "executionStartDate": "13:19:10"
      },
      ...
    ]
  }


Note: the duration is compliant with the ISO 8601 standard. 