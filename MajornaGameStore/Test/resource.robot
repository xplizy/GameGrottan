*** Settings ***
Library    SeleniumLibrary
Library    XML
Library     Collections

*** Variables ***
${username}    amrimukh2@gmail.com
${password}     Infotiv
${password2}     myData
${url}      https://localhost:7207/
${cardnumber}   1234567899876543
${cvc}     123
${checkboxMake_xpath}  //div[@id='ms-list-1']//button[@type='button']
${checkboxPassenger_xpath}  //div[@id='ms-list-2']//button[@type='button']
@{actuallist}
@{expectedlist}      5	Audi	Q7	2024-02-17	2024-02-17	5	BBE466

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











