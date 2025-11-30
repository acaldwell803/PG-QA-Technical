# QA Technical Assessment - API and Playwright Testing
This repository contains the two projects for the Associate QA Engineer assessment. These projects demonstrate C#, NUnit, Playwright, and REST testing.

## Project 1: API Testing (ApiTests Folder)
This project validates common REST API operations using a public mock API. Implemented a GET, POST, PUT, and DELETE HTTPS method as well as a negative test. How to run:
`dotnet test` in the terminal within the ApiTests folder.

## Project 2: Playwright Testing (UiTests Folder)
This project performs a UI test of the Contact Us page on the Prometheus Group website. 
### Test Steps:
1. Go to https://www.google.com.
2. Search for "Prometheus Group."
3. Validate that Prometheus Group appears.
4. Navigate to the Contact Sales page.
5. Fill the "First Name" and "Last Name" fields.
6. Submit the form.
7. Confirm that four additional required errors appear. (Changed to 7 because of the number of fields on the contact page)

How to run: `dotnet test` in the terminal within the UiTests folder.
