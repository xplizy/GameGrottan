*** Settings ***
Documentation    test for Majorna Gaming Store
Library    SeleniumLibrary
Library    XML
Library     Collections

*** Variables ***

${url}      https://majornagamestore.azurewebsites.net/
${BROWSER}      headlesschrome
${BROWSER_OPTIONS}  add_argument("--no-sandbox"); add_argument("window-size=1920,1080")
${admin_username}    admin@gamegrottan.com
${password}     GameGrottan2024!
${user}     user@user.user
${invalid_password}     GameGrottan!


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
    Wait Until Page Contains    Spel

I can add product to cart directly
    [Documentation]     Browser
    [Tags]      Products
    Wait Until Page Contains Element    //div[@class='row']//div[2]//div[1]//div[1]//img[1]        60s
    Click Button    //div[@class='row']//div[2]//div[1]//div[2]//button[1]

Check the product in the cart
    [Documentation]     add product in the cart
    [Tags]      shopping cart
    Click Button            //button[normalize-space()='0']
    Wait Until Page Contains Element    //p[normalize-space()='1 x Counter-Strike (819 SEK) - 819 SEK']    60s
    #Wait Until Page Contains Element    //input[@id='quantity']

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
    Click Button            //button[normalize-space()='0']

I can see the Products in the cart
    [Documentation]     Browser
    [Tags]      Cart
    Wait Until Page Contains    //p[normalize-space()='1 x Counter-Strike (819 SEK) - 819 SEK']    100s

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
     
I Click on Event
    [Documentation]     Event details
    [Tags]      Home Page
    Wait Until Page Contains Element    //p[normalize-space()='Events']
    Click Element    //p[normalize-space()='Events']
    Wait Until Page Contains    Niklas Tjohoo Lan

I should be able to see all events
    [Documentation]     Event details
    [Tags]      Events
    Element Should Be Visible    //p[normalize-space()='Niklas Tjohoo Lan']     timeout=10s
    Element Should Be Visible    //p[normalize-space()='string']    timeout=10s
    Close Browser

I Click on Event Details
    [Documentation]     Event details
    [Tags]      Home Page
    Wait Until Page Contains Element    //p[normalize-space()='Events']
    Click Element    //p[normalize-space()='Events']
    Wait Until Page Contains    Niklas Tjohoo Lan
    Click Element    //*[@id="Goto"]
    
I should be able to see the event details
    [Documentation]     Event details
    [Tags]      Events
    Wait Until Page Contains    Beskrivning: Best lan EVER
    Wait Until Page Contains    Start Datum:

Log in with right credentials
    [Documentation]    Admin login page
    [Tags]      Test_Admin_login
    [Arguments]     ${admin_username}     ${password}
    Click Element    //i[@class='bi bi-person fs-1']
    Input Text    //input[@id='usernameField']    ${admin_username}
    Input Password    //input[@id='passwordField']    ${password}
    Click Button    //button[@id='loginBtn']
    Wait Until Page Contains Element    //*[@id="navbarNavDropdown"]/ul/li[1]/a/p

Logout
    [Documentation]    Admin logout page
    [Tags]      Test_Admin_logout
    Click Element    //i[@class='bi bi-box-arrow-left fs-1']

Log in with wrong credentials
    [Documentation]    Admin login page
    [Tags]      Test_Admin_login
    [Arguments]     ${admin_username}     ${invalid_password}
    Click Element    //i[@class='bi bi-person fs-1']
    Input Text    //input[@id='usernameField']    ${admin_username}
    Input Password    //input[@id='passwordField']    ${invalid_password}
    Click Button    //button[@id='loginBtn']
    Wait Until Page Contains    Invalid email and/or password.

Login with valid credential for User
    [Documentation]    User login page
    [Tags]      Test_Admin_login
    [Arguments]     ${user_username}     ${password}
    Click Element    //i[@class='bi bi-person fs-1']
    Input Text    //input[@id='usernameField']    ${user_username}
    Input Password    //input[@id='passwordField']    ${password}
    Click Button    //button[@id='loginBtn']
    Wait Until Page Contains Element    //*[@id="navbarNavDropdown"]/ul/li[1]/a/p

Log in with user invalid credentials
    [Documentation]    Admin login page
    [Tags]      Test_Admin_login
    [Arguments]     ${username}     ${invalid_password}
    Click Element    //i[@class='bi bi-person fs-1']
    Input Text    //input[@id='usernameField']    ${username}
    Input Password    //input[@id='passwordField']    ${invalid_password}
    Click Button    //button[@id='loginBtn']
    Wait Until Page Contains    Invalid email and/or password.            50s

Product details page
    [Documentation]    product description
    [Tags]    See The Description
    Click Image        //div[@class='row']//div[2]//div[1]//div[1]//img[1]
    Wait Until Page Contains Element    //h2[normalize-space()='Counter-Strike']        60s

Add the product to cart
    [Documentation]    add product to cart
    [Tags]    add the product to cart
    Click Button    //button[normalize-space()='Lägg Till I Kundvagn']
    #Handle Alert    //div[@class='toast-body']
    Click Button    //button[normalize-space()='Gå tillbaka till Produkter']



    
    







    
















