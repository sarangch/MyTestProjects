Feature: CallSomeAPIs

Background: 
Given I use the following credentials for authentication
| api-auth-id                          | api-auth-signature                           |
| 47e6d4fa-687f-43f0-86e6-b842da4b5d3b | HOT+vRYgZWwrsIgYnXrkCbjg8gD7NT9I3qj2ukgVQ4c= |


Scenario: View all the customers
	When I send ViewAnyCustomer web request to CustomersAPI with the following parameters
        | pageNumber |
        | 1          |
    Then I should receive the following response Status Code OK

Scenario: View customer with specific id
	When I send ViewCustomerWithId web request to CustomersAPI with the following parameters
        | id                                   |
        | ea0ce17c-6d42-4ca9-b202-894c47688b03 |
    Then I should receive the following response Status Code OK

Scenario: View companies
	When I send ViewCompanies web request to CompaniesAPI with no parameters
    Then I should receive the following response Status Code OK
