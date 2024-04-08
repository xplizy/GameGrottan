*** Settings ***
Resource    resource.robot
Documentation    test for Majorna Gaming Store
Library    SeleniumLibrary
Suite Setup     setup




*** Test Cases ***


Access Product Page

    Given Open the browser
    When I am able to see Products
    And I click on Products
    Then I can see the Product Page

View Products in Cart
    Given











