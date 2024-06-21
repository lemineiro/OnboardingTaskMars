Feature: Skill

1. Creating a skill record
2. Editing a skill record
3. Deleting a skill record
4. Creating a skill record using special characters
5. Creating a skill record with null data
6. Creating a skill record with existing data

Scenario: A. Creating a skill record
	Given user logs into the portal
	And user navigates to the Skill tab
	When user creates a new Skill record
	Then system should save the new skill record

Scenario: B. Editing a skill record
	Given user logs into the portal
	And user navigates to the Skill tab
	And user creates a new Skill record
	When user edits the skill record
	Then system should save the edited skill record

Scenario: C. Deleting a skill record
	Given user logs into the portal
	And user navigates to the Skill tab
	And user creates a new Skill record
	When user deletes the skill record
	Then system should delete the skill record

Scenario: D. Creating a skill record using special characters
	Given user logs into the portal
	And user navigates to the Skill tab
	When user creates a new Skill record using special characters
	Then system should not save the skill record with special characters

Scenario: E. Creating a skill record using null data
	Given user logs into the portal
	And user navigates to the Skill tab
	When user creates a new Skill record using null data
	Then system should not save the null skill record

Scenario: F. Creating a skill record using existing data
	Given user logs into the portal
	And user navigates to the Skill tab
	When user creates a new Skill record using existing data
	Then system should not save the skill record with existing data