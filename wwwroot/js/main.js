

function openTab(evt, tabName) {
    
    var tabContent = document.getElementsByClassName('tab-content');
    for (var i = 0; i < tabContent.length; i++) {
        tabContent[i].style.display = "none";
    }

    
    var tabLinks = document.getElementsByClassName('tablinks');
    for (var i = 0; i < tabLinks.length; i++) {
        tabLinks[i].classList.remove('active');
    }

   
    document.getElementById(tabName).style.display = "block";
    evt.currentTarget.classList.add('active');
}
