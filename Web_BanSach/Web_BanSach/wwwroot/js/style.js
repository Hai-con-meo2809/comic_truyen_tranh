document.addEventListener('DOMContentLoaded', function() {
    var mainNav = document.getElementById('main-nav');
    var subNav = document.getElementById('sub-nav');

    // Khi di chuột vào main-nav hoặc sub-nav
    mainNav.addEventListener('mouseenter', function() {
        subNav.style.display = 'block';
    });

    subNav.addEventListener('mouseenter', function() {
        subNav.style.display = 'block';
    });

    // Khi di chuột ra khỏi main-nav hoặc sub-nav
    mainNav.addEventListener('mouseleave', function() {
        subNav.style.display = 'none';
    });

    subNav.addEventListener('mouseleave', function() {
        subNav.style.display = 'none';
    });
});






