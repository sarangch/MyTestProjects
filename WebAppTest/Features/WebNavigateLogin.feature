Feature: WebNavigateLogin

Background: 
	Given I do the test in firefox browser

Scenario: Navigate to a URL
	When I navigate to https://go.unleashedsoftware.com/v2/Account/LogOn url
	Then There should be elements with these properties 
	| id       | id       | id       |
	| btnLogOn | username | password |

Scenario: Login to the portal
	Given I navigate to https://go.unleashedsoftware.com/v2/Account/LogOn url
	When Eneter the folliwing texts in the fields by Id
	| username            | password  |
	| nina@email.com | Ab1234567 |
	And press the button with this property
	| id       | 
	| btnLogOn |
	Then There should be elements with these properties 
	| id  | id  | id  |
	| ytd | qtd | mtd |
