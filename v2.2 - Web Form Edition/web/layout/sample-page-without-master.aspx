<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN"
 "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="application/xhtml+xml; charset=UTF-8" />
    <meta http-equiv="Content-Script-Type" content="text/javascript" />
    <meta http-equiv="Content-Style-Type" content="text/css" />
    <meta name="description" content="Description of your web page goes here." />
    <meta name="keywords" content="Keywords for you web page go here. Each keyword or group of keyword phrases are separated by a comma. Keep this keyword list short and relevant to the content of this specific page and also relevant to the tile of the specific page." />
    <title>TABLE - simple</title>
</head>
<body>
    <!--
  
  MAIN NAV
  
-->
    <table border="0" cellspacing="0" cellpadding="0" id="mainnav-container">
        <tr>
            <td>
                <div class="none">
                    <a href="#maincontent">skip to the main content area of this page</a></div>
                <ul>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Home</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        News</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Products</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        About</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Contact</a></li>
                </ul>
            </td>
            <td id="mainnav-side">
                <ul>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Login</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Join</a></li>
                </ul>
            </td>
        </tr>
    </table>
    <!--
  
  SITE NAME & SLOGAN
  
-->
    <table border="0" cellspacing="0" cellpadding="0" id="header">
        <tr>
            <td>
                <a href="#" title="Site name - home page">site name</a>
                <div id="slogan">
                    Web site or company slogan goes here</div>
            </td>
        </tr>
    </table>
    <!--
  
  BREADCRUMBS
  
  -->
    <table border="0" cellspacing="0" cellpadding="0" id="breadcrumb-container">
        <tr>
            <td id="breadcrumb-left">
                <a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                    Home</a> / <a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Breadcrumb link</a> / Page Title
            </td>
            <td id="breadcrumb-right">
                <form action="#" method="get" title="Sign up to our mailing list" dir="ltr" xml:lang="en">
                <fieldset>
                    <legend>Search our site</legend>
                    <label for="search">
                        search our site</label>
                    <input onfocus="this.select()" onblur="if (this.value==''){this.value='enter search phrase'}"
                        id="search" name="search" type="text" class="searchbox" accesskey="4" value="enter search phrase"
                        size="20" />
                    <label>
                        search</label>
                    <input class="button-search" name="Search" type="button" value="Search" />
                </fieldset>
                </form>
            </td>
        </tr>
    </table>
    <!-- CONTENT CONTAINER -->
    <table border="0" cellspacing="0" cellpadding="0" id="content-container">
        <tr>
            <td id="content-left">
                <!-- 
	
	   LEFT COLUMN
	
	-->
                <ul class="link-list-vertical">
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Sub nav link one</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Sub nav link two</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Sub nav link three</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Sub nav link four</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        Sub nav link five</a></li>
                </ul>
            </td>
            <td id="content">
                <!-- 

  	   CONTENT

  	-->
                <a id="maincontent"></a>
                <h1>
                    Page title</h1>
                <img runat="server" src="~/image/photo-small.jpg" class="photosmall" width="150"
                    height="100" alt="Write a short description of the image here. It will show if the image is not loaded. Non visual browsers and search engines will also read this text."
                    title="Users will see this text when they roll over this image. Non-visual browsers will read this text to blind users." />
                <p>
                    Most of the text on this page &quot;Greeked&quot;. Its fake text used to approximate
                    how your content will look. This page has many sample elements (a form, a table,
                    lists, etc..). Use these elements to build out your site. Lorem ipsum dolor sit
                    amet, consectetuer adipiscing elit. Donec molestie. Sed aliquam sem ut arcu. Del
                    sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc.,
                    li tot Europa usa li sam vocabularium.Praesent aliquet pretium erat. Praesent non
                    odio. Pellentesque a magna a mauris vulputate lacinia. Aenean viverra per conubia
                    nostra, per. <a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        read more</a>
                </p>
                <div class="clear">
                </div>
                <form action="#" method="get" id="signup" title="Sign up to our mailing list" dir="ltr"
                xml:lang="en">
                <fieldset>
                    <legend>Join our mailing list</legend>
                    <label for="name">
                        your name
                    </label>
                    <input onfocus="this.select()" onblur="if (this.value==''){this.value='enter your name'}"
                        name="name" id="name" type="text" value="enter your name" size="20" />
                    <label for="email">
                        your email</label>
                    <input onfocus="this.select()" onblur="if (this.value==''){this.value='enter your email address'}"
                        name="email" id="email" type="text" value="enter your email address" size="20" />
                    <label for="postalcode">
                        postal code
                    </label>
                    <input onfocus="this.select()" onblur="if (this.value==''){this.value='enter your postal code'}"
                        name="postalcode" id="postalcode" value="enter your postal code" size="20" />
                    <label for="favmag1">
                        Select your favorite magazine</label>
                    <select id="favmag1" name="favmag1">
                        <option value="0" selected="selected">- - Select your favorite magazine - -</option>
                        <optgroup label="Computer">
                            <option value="1">MSDN</option>
                            <option value="2">CODE</option>
                            <option value="3">BYTE</option>
                        </optgroup>
                        <optgroup label="Lifestyle">
                            <option value="5">GQ</option>
                            <option value="6">Home and Garden</option>
                            <option value="7">US</option>
                        </optgroup>
                        <optgroup label="News">
                            <option value="8">Time</option>
                            <option value="9">The Week</option>
                            <option value="9">People</option>
                        </optgroup>
                    </select>
                    <fieldset>
                        <legend>Select your preference:</legend>
                        <label for="radioformat1">
                            <input name="radioformat" type="radio" id="radioformat1" title="html format" value=""
                                checked="checked" />
                            HTML format</label>
                        <label for="radioformat2">
                            <input title="text format" type="radio" name="radioformat" id="radioformat2" value="" />
                            Plain text format</label>
                    </fieldset>
                    <fieldset>
                        <legend>Select your favorite web site:</legend>
                        <label for="radiosite1">
                            <input type="radio" name="radiosite" id="radiosite1" title="Microsoft.com" checked="checked" />
                            Microsoft.com</label>
                        <label for="radiosite2">
                            <input type="radio" name="radiosite" id="radiosite2" title="MSDN.com" />
                            MSDN.com</label>
                        <label for="radiosite3">
                            <input type="radio" name="radiosite" id="radiosite3" title="ASP.net" />
                            ASP.NET</label>
                    </fieldset>
                    <label for="check1">
                        <input title="Subscribe" type="checkbox" name="check1" id="check1" value="" />
                        Subscribe to our mailing list</label>
                    <input class="button-big" name="Join" style="width: 75px" type="button" value="join" />
                </fieldset>
                </form>
                <table class="table" border="1" cellspacing="0" summary="Summarise the content of the table here. This table summary does not appear on screen, but is read by non-visual browsers and your blind users.">
                    <caption>
                        Short description of table contents
                    </caption>
                    <thead>
                        <tr>
                            <th scope="col" abbr="name">
                                Widget Name
                            </th>
                            <th scope="col">
                                Price
                            </th>
                            <th scope="col">
                                Features
                            </th>
                            <th scope="col" abbr="in stock">
                                Currently in stock
                            </th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th scope="col" abbr="name">
                                Widget Name
                            </th>
                            <th scope="col">
                                Price
                            </th>
                            <th scope="col">
                                Features
                            </th>
                            <th scope="col" abbr="in stock">
                                Currently in stock
                            </th>
                        </tr>
                    </tfoot>
                    <tbody>
                        <tr>
                            <td>
                                Super widget
                            </td>
                            <td>
                                $30.00
                            </td>
                            <td>
                                500 hours
                            </td>
                            <td>
                                yes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Mega widget
                            </td>
                            <td>
                                $25.00
                            </td>
                            <td>
                                200 hours
                            </td>
                            <td>
                                yes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Basic widget
                            </td>
                            <td>
                                $20.00
                            </td>
                            <td>
                                100 hours
                            </td>
                            <td>
                                no
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Plain widget
                            </td>
                            <td>
                                $15.00
                            </td>
                            <td>
                                50 hours
                            </td>
                            <td>
                                yes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Widget lite
                            </td>
                            <td>
                                free!
                            </td>
                            <td>
                                2 hours
                            </td>
                            <td>
                                yes
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" id="three-column-container">
                    <tr>
                        <td id="three-column-left">
                            <h2>
                                Column one of a three column content section</h2>
                            Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                            euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Lorem ipsum dolor
                            sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt
                            ut.
                        </td>
                        <td id="three-column-middle">
                            <h2>
                                Column three of a three column content section</h2>
                            Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                            euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.
                        </td>
                        <td id="three-column-right">
                            <h2>
                                Column two of a three column content section</h2>
                            Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh
                            euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.
                        </td>
                    </tr>
                </table>
                <p>
                    Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec molestie. Sed aliquam
                    sem ut arcu. Phasellus sollicitudin. Vestibulum condimentum facilisis nulla. In
                    hac habitasse platea dictumst. Nulla nonummy. Cras quis libero. Cras venenatis.
                    Aliquam posuere lobortis pede. Nullam fringilla urna id leo. Praesent aliquet pretium
                    erat. Praesent non odio. Pellentesque a magna a mauris vulputate lacinia. Aenean
                    viverra. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per
                    inceptos hymenaeos. Aliquam lacus. <a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        read more</a>
                </p>
                <img runat="server" src="~/image/photo-big.jpg" class="photobig" width="292" height="195"
                    alt="Write a short description of the image here. It will show if the image is not loaded. Non visual browsers and search engines will also read this text."
                    title="Users will see this text when they roll over this image. Non-visual browsers will read this text to blind users." />
                <h2>
                    Section title</h2>
                <p>
                    Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.
                    Por scientie, musica, sport etc., li tot Europa usa li sam vocabularium. Li lingues
                    differe solmen in li gram matica, li pronunciation.</p>
                <h2>
                    Section title
                </h2>
                <ul class="list">
                    <li>list item one</li>
                    <li>list item two</li>
                    <li>list item three</li>
                    <li>list item four </li>
                </ul>
                <h2>
                    Section title
                </h2>
                <ul class="link-list-vertical">
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        list link item one</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        list link item two</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        list link item three</a></li>
                    <li><a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        list link item four</a></li>
                </ul>
            </td>
            <td id="content-right">
                <!-- 
	
  	   RIGHT COLUMN
  
  	-->
                <p>
                    <a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        <img runat="server" src="~/image/ad-01.gif" width="120" height="240" alt="Write a short description of the image here. It will show if the image is not loaded. Non visual browsers and search engines will also read this text."
                            title="Users will see this text when they roll over this image. Non-visual browsers will read this text to blind users." /></a></p>
                <p>
                    <a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        <img runat="server" src="~/image/ad-02.gif" width="120" height="240" alt="Write a short description of the image here. It will show if the image is not loaded. Non visual browsers and search engines will also read this text."
                            title="Users will see this text when they roll over this image. Non-visual browsers will read this text to blind users." /></a>
                </p>
                <p>
                    <a href="#" title="Users will see this text when they roll over this link. Keep it short and consise. Use this text to clarify the purpose of the link.">
                        <img runat="server" src="~/image/ad-03.gif" width="120" height="240" alt="Write a short description of the image here. It will show if the image is not loaded. Non visual browsers and search engines will also read this text."
                            title="Users will see this text when they roll over this image. Non-visual browsers will read this text to blind users." /></a>
                </p>
            </td>
        </tr>
    </table>
    <!-- FOOTER -->
    <table border="0" cellspacing="0" cellpadding="0" id="footer">
        <tr>
            <td>
                <p>
                    One Your Street Name, City State Zip Code<br />
                    (555) 555-1212 | (555) 555-1212 fax<br />
                    Copyright &copy; 2005 Site Name
                </p>
            </td>
        </tr>
    </table>
</body>
</html>
