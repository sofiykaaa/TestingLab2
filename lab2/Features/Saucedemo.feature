Feature: Saucedemo login

  Scenario: Login as locked_out_user
    Given I am on the saucedemo website
    Then I enter username 
    Then I enter password
    When I select "Login" option
    Then I should see an error message
    Then I should close Chrome