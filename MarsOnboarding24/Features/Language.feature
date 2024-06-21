Feature: Language

1. Creating a language record
2. Editing a language record
3. Deleting a language record
4. Adding more language records than the minimum permitted
5. Creating a language record using special characters
6. Creating a language record with null data
7. Creating a language record with existing data

Scenario: A. Creating a language record
	Given user logs into the portal
	And user navigates to the Languages tab
	When user creates a new Language record
	Then system should save the new Language record

Scenario: B. Editing a language record
	Given user logs into the portal
	And user navigates to the Languages tab
	And user creates a new Language record
	When user edits the language record
	Then system should save the edited Language record

Scenario: C. Deleting a language record
	Given user logs into the portal
	And user navigates to the Languages tab
	And user creates a new Language record
	When user deletes the language record
	Then system should delete the Language record

Scenario: D. Adding more language records than the minimum permitted
	Given user logs into the portal
	And user navigates to the Languages tab
	When user creates multiple records
	Then user should not be able to add any more language records

Scenario: E. Creating a language record using special characters
	Given user logs into the portal
	And user navigates to the Languages tab
	When user creates a new Language record using special characters
	Then system should not save the record

Scenario: F. Creating a language record using null data
	Given user logs into the portal
	And user navigates to the Languages tab
	When user creates a new Language record using null data
	Then system should not save the record with null data

Scenario: G. Creating a language record using existing data
	Given user logs into the portal
	And user navigates to the Languages tab
	When user tries to create a duplicate record
	Then system should not save the record using existing data
