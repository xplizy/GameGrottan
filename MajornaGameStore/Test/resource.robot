*** Settings ***
Documentation    test for Majorna Gaming Store
Library    SeleniumLibrary
Library    XML
Library     Collections

*** Variables ***
${username}    amrimukh2@gmail.com
${password}     Infotiv
${password2}     myData
${url}      https://localhost:7207/


*** Keywords ***
setup
    Set Selenium Speed    1    #används för att styra hastighet
    Open Browser    browser=Chrome
    Go To   ${url}

Open the browser
    [Documentation]     Browser
    [Tags]      VG_Test1_browser
    Open Browser    https://localhost:7207/   chrome
    Maximize Browser Window    
    Wait Until Page Contains    Välkommen till Majorna Gaming
    
I can see the landing page
    [Documentation]     Browser
    [Tags]      VG_Test1_browser
    Wait Until Page Contains Element    


I am able to see Products
    [Documentation]     Browser
    [Tags]      Products
    Wait Until Page Contains Element    //a[normalize-space()='Produkter']
    
I click on Products
    [Documentation]     Browser
    [Tags]      Products
    Click Element    //a[normalize-space()='Produkter']

I can see the Product Page
    [Documentation]     Browser
    [Tags]      Products
    Wait Until Page Contains    Produkter
    
I am able to see Cart
    [Documentation]     Browser
    [Tags]      Cart
    Wait Until Page Contains Element   //a[normalize-space()='Kundvagn']

I click on Cart
    [Documentation]     Browser
    [Tags]      Cart
    Click Element        //a[normalize-space()='Kundvagn']

I can see the Products in the cart
    [Documentation]     Browser
    [Tags]      Cart
    Wait Until Page Contains    Elden Ring

Select the product to increase the quantity
    [Documentation]     Browser
    [Tags]      shopping cart
    Wait Until Element Is Visible    //a[normalize-space()='Elden Ring']
    Click Element    id=quantity
    #Select From List By Index    //div[2]//form[1]//input[1]   7
    
#Select the product to decrease the quantity
    #[Documentation]     Browser
    #[Tags]      shopping cart
    #Click Button    //div[2]//form[1]//input[1]
    #Select From List By Index    //div[2]//form[1]//input[1]    2



    
















