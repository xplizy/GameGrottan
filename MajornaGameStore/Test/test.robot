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

Access Landing Page
    Given Open the browser
    When I am able to see the landing page with Welcome message
    And I am able to see the logo
    Then I can see the links

Access Product Page

    Given Open the browser
    When I am able to see Products
    And I click on Products
    Then I can see the Product Page
    And Verify Product List Is Visible

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













