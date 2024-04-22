*** Settings ***
Resource    resource.robot
Documentation    test for Majorna Gaming Store
Library    SeleniumLibrary
Suite Setup     setup

*** Test Cases ***
Blazorapp running
    Open Browser        browser=${BROWSER}      options=${BROWSER_OPTIONS}
    Go To   ${url}
    Wait Until Page Contains    Välkommen till Majorna Gaming

Access Landing Page
    Given Open the browser
   # When I am able to see the landing page with Welcome message
    And I am able to see the logo
    Then I can see the links

Access Product Page

    Given Open the browser
    When I am able to see Products
    And I click on Products
    And I can see the Product Page
    Then Verify Product List Is Visible

Add product into the cart directly

    Given Open The Browser
    When I click on Products
    And I can add product to cart directly
    And Check the product in the cart

View Products in Cart
    Given Open the browser
    When I am able to see Cart
    And I click on Cart
    Then I can see the Products in the cart

Checking the product quantity
    [Documentation]    Checking the product quantity by increasing the value
    [Tags]    product quantity

    Given open the browser
    When I Click On Cart
    Then I can see the Products in the cart
    And I can increase the product quantity
    #Then I can decrease the product quantity

Remove item from the cart
    [Documentation]    Remove the item in the cart
    [Tags]    Remove product

    Given open the browser
    When I Click On Cart
    Then I can see the Products in the cart
    And I can remove the product

Access Event Page
    [Documentation]    Access Event Page
    [Tags]  Events
    Given open the browser
    When I Click on Event
    Then I should be able to see all events

Login to admin page with valid credentials
    [Documentation]    Login with valid credentials
    [Tags]  Admin_Login
    Log in with right credentials       ${admin_username}      ${password}
    Logout

Login to admin page with invalid credentials
    [Documentation]    Login with invalid credentials
    [Tags]  Admin_Login
    Log in with wrong credentials       ${admin_username}      ${invalid_password}
















