*** Settings ***
Library    SeleniumLibrary
Library    XML
Library     Collections

*** Variables ***

${url}      https://localhost:7207/
${BROWSER}      headlesschrome
${BROWSER_OPTIONS}  add_argument("--no-sandbox"); add_argument("window-size=1920,1080")


*** Keywords ***
setup
    Set Selenium Speed    1    #används för att styra hastighet
    Open Browser    browser=${BROWSER}  options=${BROWSER_OPTIONS}
    Go To   ${url}

Open the browser
    [Documentation]     Browser
    [Tags]      VG_Test1_browser
    Open Browser    browser=${BROWSER}  options=${BROWSER_OPTIONS}
    Go To   ${url}
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













