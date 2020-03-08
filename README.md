# dealeron
salestax
Problem
SALES TAX PROBLEM

Basic sales tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are exempt. 
Import duty is an additional sales tax applicable on all imported goods at a rate of 5%, with no exemptions. 
When I purchase items I receive a receipt that lists the name of all the items and their price (including tax), finishing with the total cost of the items, and the total amounts of sales tax paid. 
The rounding rules for sales tax are that for a tax rate of n%, a shelf price of p contains np/100 rounded up to the nearest 0.05 amount of sales tax.

SOLUTION

Implemented a simple sales tax calculator application, which can receive dynamic purchased item list from user input and calculates Taxes, Individual and Total amount and display results in desired format. 

ASSUMPTION

1. Shopping cart data will be stored temporarily, not storing data in database. 
2. Implementation should be done by following all Good Software development practices and using any technology.

3.The following assumption is made from the input requirement 
a. To keep application more accurate and maintainable instead of using "imported" word to decide if item was imported, relied on user input.
b. Assumed Price of any item always will be positive.

TECNOLOGY

MVC and C#


