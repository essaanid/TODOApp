
# TODO APP

TODO application allows users to list, create, edit, delete and mark tasks as done.

This project is developed using ABP.io framework

## Run
To run this project please follow thses steps please:

 - Open solution file using VS 2022.
 - Run Migrator Project, this will create database and generate tables.
 - When Migration Process is completed, Run Host Project which will show Swagger ui and all APIs listed here.
 - To test Task Item API, firstly you have to be authorized by clicking on "Authorize" button which will open login page, enter default username & password for abp admin:
 username = admin,
 password = 1q2w3E*
 - You will be returned to prev page "Swagger ui"
 - Go to Abp users and run get users api to get any user Id to complete your test,
 - Go to Items Apis Section and click on Try Out Button and enter your request params with userId that you got in prev step to insert new Task Item for this user.
 - you can complete your test for other Task Items APIs.

