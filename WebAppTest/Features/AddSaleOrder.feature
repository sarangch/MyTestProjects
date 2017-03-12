Feature: AddSaleOrder

Background: 
	Given I do the test in firefox browser
	And I navigate to https://go.unleashedsoftware.com/v2/Account/LogOn url
	And Eneter the folliwing texts in the fields by Id
	| username            | password  |
	| qa+chehrehsa@unl.s | Ab1234567 |
	And press the button with this property
	| id       | 
	| btnLogOn |
	And I wait for 3000 msec

Scenario: Create sale order
	When I navigate to https://go.unleashedsoftware.com/v2/SalesOrder/Update url
	And Eneter the folliwing texts in the fields by Id
	| SelectedCustomerCode            | 
	| EMWAR | 
	And I wait for 1000 msec
	And press the button with this property
	| cssselector       | 
	| li.ui-menu-item |
	And I wait for 3000 msec
	And Eneter the folliwing texts in the fields by Id
	| ProductAddLine            | 
	| lounge | 
	And I wait for 1000 msec
	And press the button with this property
	| cssselector       | 
	| li.ui-menu-item |
	And I wait for 3000 msec
	And Eneter the folliwing texts in the fields by Id
	| QtyAddLine            | 
	| 2 | 
	And press the button with this property
	| id       | 
	| btnAddOrderLine |
	And I wait for 3000 msec
	And press the button with this property
	| id       | 
	| btnComplete |
	Then There should be elements with these properties
	| cssselector                               |
	| #OrderStatusDisplay.lozenge.Completed |
