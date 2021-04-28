Getting Started
## @Author team development

Controller method work

1-> HomeController -> 1.  Index() -> 
					  2.  Login() -> retuns login view
					  2.  [HttpPost]Login() -> to authorize a user, logs in if the credentials are correct
					  3.  Logout() -> logs out the user and deletes the cookie

2-> AdminConroller -> 1.  Home() -> View with addition of adding customers, users and edit users
					  2.  AddUser() -> View with Add user layout
					  3.  [HttpPost]AddUsers() -> to insert new user details to the database
					  4.  ManageUsers() -> to get all the user values from the database and display in the data table
					  5.  DeleteUsers(int id) -> takes id of the selected user and deletes the data from database
					  6.  EditUsers() -> need to pass id while calling this method, edits the user's data'
					  7.  AddCustomer() -> View with Add customer layout
					  8.  [HttpPost]AddCustomers() -> to insert new customer details to the database
					  9.  ManageCustomers() -> to get data of customer from database and display in datatable
					  10. DeleteCustomers(int id) -> deletes the selected customer
					  11. EditCustomers() -> need to pass id, edits the customer data

3-> UserServices ->   1.  GetUserById(int id) -> Gets the current user's id
					  2.  TryValidateUser() -> checks if the credentials entered while logging in is registered in the database or not.
											   also generates a list of claims which consists of the logged in user's information


Date: 27th April 2021
samyush- logout directed to index.html
validation added 
passing of data to view working
#################################

![samyush Banner](http://1.bp.blogspot.com/-15jx1ht9-Ys/VH5CasSmByI/AAAAAAAATdg/S9jVPJpaSmU/s1600/chee1.jpg)


# App Dev 2nd CW Group	

App Dev 2nd CW using C# asp.net core.

## For Getting Started
Introduction above.

## @author Team Development(https://github.com/Samyush)


- [Lab: Write your first here we go app](https://flutter.dev/docs/get-started/codelab)
- [Cookbook: Useful C# documents](https://flutter.dev/docs/cookbook)

>I am a flutter and laravel full stack developer, you can check upon [my instagram profile](https://www.instagram.com/samyush/)

![End Banner](https://github.com/londonappbrewery/Images/blob/master/readme-end-banner.png)

@ByRasana
>--unsetted background image in header.masthead
and hid overflow to eliminate whitespace in background body!
>--removed navbar buttons and sign up link in login page
>--rendered customer data in datatable, added background image to remove whitespace, removed placeholder in login page to eliminated congested space
