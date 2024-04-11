*** Settings ***
Resource    resource.robot
Documentation    test for Majorna Gaming Store
Library    SeleniumLibrary
Suite Setup     setup

*** Test Cases ***

Access landing page
    Given Open The Browser
    When I can see the address on landing page
    Then I Can See The Layout On Landing Page


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

Checking the product quantity
    [Documentation]    Checking the product quantity by increasing the value
    [Tags]    product quantity

    Given open the browser
    When I Click On Cart
    Then Select the product to increase the quantity
    #And I can increase the product quantity
    #Then I can decrease the product quantity












