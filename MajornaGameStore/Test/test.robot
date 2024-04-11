*** Settings ***
Resource    resource.robot
Documentation    test for Majorna Gaming Store
Library    SeleniumLibrary
Suite Setup     setup

*** Test Cases ***

Verify Blazorapp running
    Open Browser        browser=${BROWSER}      options=${BROWSER_OPTIONS}
    Go To   ${url}
    Wait Until Page Contains    Välkommen till Majorna Gaming


Access Product Page

    Given Open the browser
    When I am able to see Products
    And I click on Products
    Then I can see the Product Page
    And I will be able to see the list of available products

View Products in Cart
    Given Open the browser
    When I am able to see Cart
    Then I click on Cart
    #Then I can see the Products in the cart

Checking the product quantity
    [Documentation]    Checking the product quantity by increasing the value
    [Tags]    product quantity

    Given open the browser
    When I Click On Cart
    Then Select the product to increase the quantity
    #And I can increase the product quantity
    #Then I can decrease the product quantity












