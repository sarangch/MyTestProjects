Feature: AddProduct
	
Background: 
	Given I do the test in firefox browser
	And I navigate to https://go.unleashedsoftware.com/v2/Account/LogOn url
	And Eneter the folliwing texts in the fields by Id
	| username            | password  |
	| qa+chehrehsa@unl.sh | Ab1234567 |
	And press the button with this property
	| id       | 
	| btnLogOn |
	And I wait for 1000 msec

Scenario: Navigate to add product page
	When I navigate to https://go.unleashedsoftware.com/v2/Product/Update url
	And Eneter the folliwing texts in the fields by Id
	| Product_ProductCode            | Product_ProductDescription  |
	| 123456 | Some description Blah Blah |
	And press the button with this property
    | id      |
    | btnSave |
	Then There should be element located by cssselector with the following locator and text
	| span#messageBoxContent.msgContent                                 |
	| You have updated the product successfully. |