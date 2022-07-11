export function getBodyClasses() {
    const classList = [];
    document.body.classList.forEach(className => { classList.push(className); });
    return classList;
}

export function setFontClass(fontClass) {
    const toRemove = [];
    const body = document.body;

    if (!fontClass.startsWith('font-')) { fontClass = `font-${fontClass}` }

    body.classList.forEach(className => {
        if (className !== fontClass && className.startsWith("font-")) {
            toRemove.push(className);
        }
    });

    if (!body.classList.contains(fontClass)) {
        body.classList.add(fontClass);
    }

    if (toRemove.length > 0) {
        toRemove.forEach(className => { body.classList.remove(className); })
    }
}

export function setThemeClass(themeClass) {
    const toRemove = [];
    const body = document.body;

    if (!themeClass.startsWith('theme-')) { themeClass = `theme-${themeClass}` }
    themeClass = themeClass.toLowerCase();
    body.classList.forEach(className => {
        if (className !== themeClass && className.startsWith("theme-")) {
            toRemove.push(className);
        }
    });

    if (!body.classList.contains(themeClass)) {
        body.classList.add(themeClass);
    }

    if (toRemove.length > 0) {
        toRemove.forEach(className => { body.classList.remove(className); })
    }
}

export function setSkinClass(skinClass) {
    const toRemove = [];
    const body = document.body;

    if (!skinClass.startsWith('skin-')) { skinClass = `skin-${skinClass}` }
    skinClass = skinClass.toLowerCase();
    body.classList.forEach(className => {
        if (className !== skinClass && className.startsWith("skin-")) {
            toRemove.push(className);
        }
    });

    if (!body.classList.contains(skinClass)) {
        body.classList.add(skinClass);
    }

    if (toRemove.length > 0) {
        toRemove.forEach(className => { body.classList.remove(className); })
    }
}

export function setRtl(active) {
    document.getElementsByTagName('HTML')[0].style.direction = active ? 'rtl' : 'ltr';
    const body = document.body;

    if (body.classList.contains('rtl') && !active) {
        body.classList.remove('rtl');
    } else if (!body.classList.contains('rtl') && active) {
        body.classList.add('rtl');
    }
}