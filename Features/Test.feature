Feature: Google Search

A short summary of the feature

@test
Scenario: Google Search Test 01
	Given i navigate to google
	Then i enter  "Automation Testing" Data on Search bar
	Then i Click Search

	@test
Scenario: Google Search Test 02
	Given i navigate to google
	Then i enter  "Manual Testing" Data on Search bar
	Then i Click Search