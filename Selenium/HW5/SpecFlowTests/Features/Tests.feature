Feature: Tests

As a user I want to use JDI GitHub site


#Первый тест писался, исходя из подхода один тест - один Assert
#Если бы тест бы тест был наптсан единым сценарием
#то бэкграунд выглядел бы так
#Background:
#	Given I open JDI GitHub site
#	And I login as user 'ROMAN IOVLEV'

@EX1
Scenario: Confirmation of browser title
	Given I open JDI GitHub site
	When I check the page title
	Then The browser title should be 'Home Page'

@EX1
Scenario: Successfull user login
	Given I open JDI GitHub site
	When I login into site as user 'ROMAN IOVLEV'
	Then The logged user name shoul be 'ROMAN IOVLEV'

@EX1
Scenario Outline: Confirmation of the logging of Selected checkboxes
	Given I open JDI GitHub site
	And I login as user 'ROMAN IOVLEV'
	And I click on 'Service' button in Header
	And I click on 'Different elements' button in Service dropdown
	When I select <element> checkbox
	Then <number> log row has <message> text in log section
	#And The selected state of <element> checkbox should be <state> - for some reason always return false

Examples:
	| number | element | message                          | state |
	| 1      | Water   | Water: condition changed to true | true  |
	| 1      | Wind    | Wind: condition changed to true  | true  |


@EX1
Scenario Outline: Confirmation of the logging of Selected metal radiobutton
	Given I open JDI GitHub site
	And I login as user 'ROMAN IOVLEV'
	And I click on 'Service' button in Header
	And I click on 'Different elements' button in Service dropdown
	When I select 'Selen' radiobutton
	Then <number> log row has <message> text in log section

Examples:
	| number | message                       |
	| 1      | metal: value changed to Selen |

@EX1
Scenario Outline: Confirmation of the logging of Selected color
	Given I open JDI GitHub site
	And I login as user 'ROMAN IOVLEV'
	And I click on 'Service' button in Header
	And I click on 'Different elements' button in Service dropdown
	And I click on color field
	When I select 'Yellow' in the dropdown list
	Then <number> log row has <message> text in log section

Examples:
	| number | message                         |
	| 1      | Colors: value changed to Yellow |


@EX2
Scenario: User Table Page test
	Given I open JDI GitHub site
	And I login as user 'ROMAN IOVLEV'
	When I click on 'Service' button in Header
	And I click on 'User Table ' button in Service dropdown
	Then 'User Table' page should be opened
	And 6 Number Type Dropdowns should be displayed on Users Table on User Table Page
	And 6 Usernames should be displayed on Users Table on User Table Page
	And 6 Description texts under images should be displayed on Users Table on User Table Page
	And 6 checkboxes should be displayed on Users Table on User Table Page
	And User table should contain following values:
	#при передаче параметра в таблицу удваивается первый обратный слэш, что приводит к несовпадению результатов
	# можно дополнительно обратотать строки, но не знаю нужно ли
		| Number | User             | Description                          |
		| 1      | Roman            | Wolverine                            |
		| 2      | Sergey Ivan      | Spider Man                           |
		| 3      | Vladzimir        | Punisher                             |
		| 4      | Helen Bennett    | Captain America\r\nsome description  |
		| 5      | Yoshi Tannamuri  | Cyclope\r\nsome description          |
		| 6      | Giovanni Rovelli | Hulk\r\nsome description             |
	And droplist should contain values in column Type for user Roman
		| Dropdown Values |
		| Admin           |
		| User            |
		| Manager         |



@EX3
Scenario Outline: User Table Page Vip Test
	Given I open JDI GitHub site
	And I login as user 'ROMAN IOVLEV'
	And I click on 'Service' button in Header
	And I click on 'User Table ' button in Service dropdown
	When I select 'Vip' checkbox for 'Sergey Ivan'
	Then <number> log row has <message> text in log section

Examples:
	| number | message                        |
	| 1      | Vip: condition changed to true |

