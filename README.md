# Derivco

In this repo you will find a solution to the exam. 
There are two main console projects, for Question 1 and Question 2 solutions, as well as a unit test project that contains a set of tests for the solutions developed for the exam.

**Tools:** 
- [.net core runtime](https://dotnet.microsoft.com/en-us/download/dotnet/3.1): Version 3.1

**Instructions to run QuestionOne:**
- ```dotnet build```
- ```dotnet run```

**Instructions to run QuestionTwo:**
- ```dotnet build```
- ```dotnet run [optional args]```
  - --d: number of decks
  - --p: to activate suit precedence
  - --c: number of cards per suit

For example ```dotnet run --d 2 --p --c 10```

**Instructions to run the tests**
- Move to UnitTests folder
- ```dotnet test```
