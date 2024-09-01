# Maaser Trackerr
An application  that utilizes C# in the backend and React in the frontend. The user can add income, maaser payments and sources of income to this site and effectively keep track of his Maaser obligation.

There is an overview page that displays accurate data about the state of his income and Maaser, and an Income page where the user can sort all his income by source.


## To Run this Project:
Clone the github repository and save it to your local device
Use the command line to navigate to the file location
Run the following prompts on the command line to set up the database
```sh
dotnet ef migrations add initial
dotnet ef database update
```

Run the following prompts on the command line to build and run the project
```sh
dotnet watch run
```
