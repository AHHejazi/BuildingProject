var buildingApp = buildingApp || {};
var cultureCookieName = '.AspNetCore.Culture';
buildingApp.switchLang = (lang) => {
    
    if (buildingApp.isArabic()) {
        buildingApp.setCookie(cultureCookieName, "c=en-GB|uic=en-GB");
    } else {
        buildingApp.setCookie(cultureCookieName, "c=ar-SA|uic=ar-SA");
    }

    window.location = window.location.href;
    e.preventDefault();
};

buildingApp.isArabic = () => {
    return buildingApp.getCurrentLang() === 'ar';
}

buildingApp.setCookie = (name, value, days) => {
    var expires;
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    } else {
        expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
};

buildingApp.getCurrentLang = () => {
    var lang = 'ar';
    var cultureFromCookie = decodeURIComponent(buildingApp.readCookie(cultureCookieName));
    var langFromHtmlTag = $('html').attr('lang');

    if (cultureFromCookie !== undefined && cultureFromCookie !== "" && cultureFromCookie !== null) {// && cultureFromCookie != null added by Hoda because of error in pubish event button close
        lang = (cultureFromCookie === 'ar-SA' || cultureFromCookie === 'ar' || cultureFromCookie.indexOf('ar-SA') > -1) ? 'ar' : 'en';
    } else if (langFromHtmlTag !== undefined && langFromHtmlTag !== "") {
        lang = langFromHtmlTag;
    }

    return lang;
};

buildingApp.readCookie = (name) => {
    var nameEq = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEq) === 0) return c.substring(nameEq.length, c.length);
    }
    return null;
};