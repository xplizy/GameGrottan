*** Settings ***
Resource    resource.robot
Documentation    test for Majorna Gaming Store
Library    SeleniumLibrary
Suite Setup     setup

*** Test Cases ***

Access landing page
    Given Open The Browser
    When i can access the landing page
    Then i can see the layouts on page


Access Product Page

    Given Open the browser
    When I am able to see Products
    And I click on Products
    Then I can see the Product Page

View Products in Cart
    Given Open the browser
    When I am able to see Cart
    And I click on Cart
    Then I can see the Products in the cart

Adding update quantity
    Given open the browser












