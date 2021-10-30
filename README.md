# EAPrime

## Introduction
This is a C# console application created in Visual Studio that provides a list of [prime factorizations](https://www.mathsisfun.com/prime-factorization.html) for a given list of numbers specified within a text file.
This repository contains the Visual Studio Solution as well as two projects, one being the actual console application and the other being unit tests. I used [NUnit](https://nunit.org/) for testing.

## Deliverables
An executable named **EAPrime.exe** can be found under **Releases**. It must be run from the command line like so:
```
.\EAPrime.exe [arguments]
```

## Running
The program can be run with optional flags in addition to required flags. The usage is as follows:
| Flag         | Params    | Required  | Effect     |
|--------------|-----------|-----------|------------|
| -h           |           | No        | Displays usage information and any optional flags.        |
| -d           | [path]    | Yes       | Used to specify the path to input file.        |
| -p           |           | No        | Prints out a fancy title.        |

Here is an example:
```
.\EAPrime.exe -p -d input.txt
```
This runs the program with fancy title enabled and **.\input.txt** as the specified filepath.
