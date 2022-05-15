## **Simple Calculator**

Folders that start with "Calc" are the API folders. 

Limitations and assumptions are stated at the Readme file.

---

## Managing API/Lambda using AWS CLI

Make sure AWS CLI is installed and configured. 

-- Create a lambda function (.NET)

open console and navigate to directory/folder where you want to create the function (e.g. cd C:\Calculator)

run: dotnet new lambda.EmptyFunction --name [function name]


-- Deploy a lambda function

open console and navigate to directory/folder where the function is (e.g. cd C:\Calculator\CalcAdd\src\CalcAdd)

run: dotnet lambda deploy-function [function name]

---

## API

** Addition: https://8k24kpt9vk.execute-api.us-east-1.amazonaws.com/stage/add?num1=5&num2=2

** Subtraction: https://8k24kpt9vk.execute-api.us-east-1.amazonaws.com/stage/sub?num1=5&num2=2

** Multiplication: https://8k24kpt9vk.execute-api.us-east-1.amazonaws.com/stage/mul?num1=5&num2=2

** Division: https://8k24kpt9vk.execute-api.us-east-1.amazonaws.com/stage/div?num1=5&num2=2

---

## Console app for testing
Console app is located at ConsoleApp folder

---
