*** Settings ***
Documentation    test for Majorna Gaming Store
Library    SeleniumLibrary
Library    XML
Library     Collections

*** Variables ***

${url}      https://majornagamestore-staging.azurewebsites.net/
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
    Wait Until Page Contains    Hem        60s
    
I can see the address on landing page
    [Documentation]     Browser
    [Tags]      VG_Test1_browser
    Wait Until Page Contains Element    //p[normalize-space()='GameGrottan Majorna']        60s

I am able to see Products
    [Documentation]     Browser
    [Tags]      Products
    Wait Until Page Contains Element    //p[normalize-space()='Spel']
    
I click on Products
    [Documentation]     Browser
    [Tags]      Products
    Click Element    //p[normalize-space()='Spel']

I can see the Product Page
    [Documentation]     Browser
    [Tags]      Products
    Wait Until Page Contains    Produkter

I can add product to cart directly
    [Documentation]     Browser
    [Tags]      Products
    Wait Until Page Contains Element    //a[normalize-space()='Counter-Strike']        60s
    Click Button    //div[2]//div[1]//div[2]//button[1]

Check the product in the cart
    [Documentation]     add product in the cart
    [Tags]      shopping cart
    Click Element        //a[normalize-space()='Kundvagn']
    Wait Until Page Contains Element    //p[normalize-space()='1 x Counter-Strike (819 SEK) - 819']    60s
    Wait Until Page Contains Element    //input[@id='quantity']

Verify Product List Is Visible
    [Documentation]     Browser
    [Tags]      Products
    Wait Until Page Contains Element    css=.item-container     60s
    Element Should Be Visible    css=.item-container
    Close Browser

I am able to see Cart
    [Documentation]     Browser
    [Tags]      Cart
    Wait Until Element Is Visible  //a[normalize-space()='Kundvagn']    timeout=60s

I click on Cart
    [Documentation]     Browser
    [Tags]      Cart
    Click Element        //i[@class='bi bi-cart3 fs-1']

I can see the Products in the cart
    [Documentation]     Browser
    [Tags]      Cart
    Wait Until Page Contains    //p[normalize-space()='1 x Counter-Strike (819 SEK) - 819']    100s

I can increase the product quantity
    [Documentation]     Browser
    [Tags]      shopping cart
    Wait Until Element Is Visible    //p[normalize-space()='1 x Counter-Strike (819 SEK) - 819']    60s
    Click Element    //input[@id='quantity']
    Select From List By Index    //div[2]//form[1]//input[1]   7
    
I can decrease the product quantity
    [Documentation]     Browser
    [Tags]      shopping cart
    Wait Until Element Is Visible    //p[normalize-space()='1 x Counter-Strike (819 SEK) - 819']    60s
    Click Button    //input[@id='quantity']
    Select From List By Index    //div[2]//form[1]//input[1]    2


I am able to see the landing page with Welcome message
    [Documentation]     Browser
    [Tags]      Home Page
    Wait Until Page Contains    Välkommen till Majorna Gaming

I am able to see the logo
    [Documentation]     Browser
    [Tags]      Home Page
    Wait Until Page Contains Element    //img[@alt='Majorna Gaming Logo']

I can see the links
    [Documentation]     Browser
    [Tags]      Home Page
    Wait Until Page Contains Element    //a[@class='nav-link active']

I can remove the product
    [Documentation]     Browser
    [Tags]      Home Page
     Wait Until Page Contains    //p[normalize-space()='1 x Counter-Strike (819 SEK) - 819']    100s
     Click Button    //button[normalize-space()='Remove']
     Wait Until Page Contains Element    //p[normalize-space()='Totalt: Sek 0']








    
















