# Candidate-Kanban
Simple web-based Kanban board to manage a hiring process and its candidates. This project is built with Angular 14 (front end), .NET 6 (Api back end) and MySQL database. There is features and assumptions made during development:
## Kanban board
Kanban is the main board when loading application, there will be 4 static stages on the board: Applied, Interviewing, Offered, Hired. Users can create Candidates at any stage on the board by click on "Add candidate..." link at the bottom of each stage. Users can drag and drop any Candidate to any stage on the board, Candidate stage will be updated. To go to Candidate detail page, Users can click on Candidate Name on the board.

Each Candidate on the board will display Name (Firstname + Lastname), Email and PhoneNumber

![image](https://github.com/rotkle/Candidate-Kanban/assets/99155483/e6de14cc-19e7-491d-b27e-5c0787abeec8)

## Create Candidate
When Users click on "Add candidate..." link, a Create Candidate form will appear like below

![image](https://github.com/rotkle/Candidate-Kanban/assets/99155483/77a7c51c-27fe-4aff-a6f4-24cfb4871e7a)

In this form, Users can add Candidate Firstname, Lastname, Email, Phone number and Jobs which Candidate is applied to. There is validation on this form included:
1. Firstname, Lastname, Email and Phone number is required, Jobs is optional
2. Email and Phone number can not be duplicate in database
3. Email should be provided in correct format xxx@xxx.xxx
4. Phone number should be provided in numbers
5. Firstname and Lastname max length is 100 characters
6. Email max length is 200 characters
7. Phone number max length is 30 characters

To specific jobs which Candidate is going to apply, Users can select Jobs dropdown items. To save Candidate data, hit "Submit" button or "Cancel" to go back to the board without save candidate to database. When Candidate save successful, a success message is showed and return to the board with lastest data

There is a small "X" button on the right corner of the board, Users can click that button to exit Create Candidate form

## Candidate detail page
When Users click on any Candidate name on the board, application will redirect to Candidate detail page

![image](https://github.com/rotkle/Candidate-Kanban/assets/99155483/e31d15a5-6045-4be4-b5ca-695a2f544568)

The validations on detail page is the same with Create Candidate form. Users can edit stage of Candidate by select the Status on the detail page.

# Setup and Run application
To build and run the project, firstly pull the source code from github to local, then follow the instructions for each project below.
## Kanban.Api
1. Download [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) and install
2. Go to the Kanban.Api folder
3. Open command line and run `dotnet restore` to restore nugets packages
4. Run `dotnet build` to build project
5. Run `dotnet run` to run project
6. The project is run at `http://localhost:4000`

## Kanban.Angular
1. Download [NodeJs v16.10](https://nodejs.org/en/blog/release/v16.10.0) (or higher) and install
2. Go to the Kanban.Angular folder
3. Open command line and run `npm install` to install node and angular packages
4. Run `npm start` to start project
5. Open browser and go to `http://localhost:4200`
6. The App is loaded and ready

## Kanban.Api.Test
There is Test project is added to test APIs functional, to run test
1. Go to the Kanban.Api.Test folder
2. Open command line and run `dotnet restore`
3. Run `dotnet build` then `dotnet test`

## MySQL server
The data used in this project is stored in an online MySQL server database. If you want to see the data then go to [phpMyAdmin](https://www.phpmyadmin.co/) and login with this credential
- Host: sql6.freesqldatabase.com
- Database name: sql6691329
- Database user: sql6691329
- Database password: nhxVK5lwSZ
- Port number: 3306
