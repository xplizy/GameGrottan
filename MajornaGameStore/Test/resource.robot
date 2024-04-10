*** Settings ***
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
    Wait Until Page Contains    Välkommen till Majorna Gaming
    
I can see the landing page
    [Documentation]     Browser
    [Tags]      VG_Test1_browser
    

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
    Click Element    //a[normalize-space()='Kundvagn']

I can see the Products in the cart
    [Documentation]     Browser
    [Tags]      Cart
    Wait Until Page Contains    Elden Ring













