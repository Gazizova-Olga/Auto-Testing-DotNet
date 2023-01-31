Feature: Tests

As a user I want to login into service, and 

@tag1
Scenario: Confirmation of browser title
	Given The browser navigates to 'https://jdi-testing.github.io/jdi-light/index.html'
	When I check the page title
	Then The browser title should be 'Home Page'

	#Example:
	#| url | title |
	#| https://jdi-testing.github.io/jdi-light/index.html | Home Page |
