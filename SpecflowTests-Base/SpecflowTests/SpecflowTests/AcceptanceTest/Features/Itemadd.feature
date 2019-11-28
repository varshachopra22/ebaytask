Feature: SpecFlowFeature1
	In order to purchase an item
	As a customer 
	I need to search and add that item to my cart

@mytag
Scenario: Add an item to cart
	Given I have entered books in the search bar
	And selected the first item
	When I press add to cart
	Then that item should be added to my cart