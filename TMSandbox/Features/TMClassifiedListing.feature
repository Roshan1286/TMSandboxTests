Feature: TMClassifiedListing
![TradeMeSadboxTest]( e.g. https://api.tmsandbox.co.nz/v1/Categories/232/Details.json?catalogue=false)
Simple Test to validate category id with expected values

Background:
	Given TMSandbox service is up and running

@CategoryCheck @PositiveTest
Scenario: Catergory Validator
	# Arrange
	Given The CategoryId is 6327 and Catalogue is set to false
	# Act
	When When a TMSandbox service request is made
	# Assert
	Then The service response should contain Name as Carbon credits and CanRelist attribute should be true
	And The service response should contain Promotions element with name as Gallery with description as Good position in category

@CategoryCheck @PositiveTest
Scenario: Catergory Validator Tabular Format
	Given The CategoryId is <CategoryId> and Catalogue is set to <Catalogue>
	When When a TMSandbox service request is made
	Then The service response should contain Name as <ExpectedCategoryName> and CanRelist attribute should be <ExpectedCanRelist>
	And The service response should contain <Section> element with name as <SectionName> with description as <SectionDescription>
Examples:
	| CategoryId | Catalogue | ExpectedCategoryName | ExpectedCanRelist | Section    | SectionName | SectionDescription          |
	| 6327       | false     | Carbon credits       | true              | Promotions | Gallery     | Good position in category   |
	#Following are extra examples if there was more testing to be done on this API
	| 6327       | false     | Carbon credits       | true              | Promotions | Feature     | Better position in category |
	| 6327       | true      | Carbon credits       | true              | Promotions | Gallery     | Good position in category   |
	| 232        | false     | Card adapters        | true              | Promotions | Basic       | Lowest position in category |