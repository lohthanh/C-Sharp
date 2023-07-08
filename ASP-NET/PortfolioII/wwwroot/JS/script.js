
let currentPage = window.location.href;

// const homeLink = document.getElementById("home-link");
// const projectsLink = document.getElementById("projects-link");
// const contactLink = document.getElementById("contact-link");

let navLinks = document.getElementsByClassName("nav-link");

// if (currentPage.includes("/")) {
//     homeLink.classList.add("active-link");
// } else if (currentPage.includes("/projects")) {
//     projectsLink.classList.add("active-link");
// } else if (currentPage.includes("/contact")) {
//     contactLink.classList.add("active-link");
// }

for (let i = 0; i < navLinks.length; i++) {
    let link = navLinks[i];
    if (link.href === currentPage) {
        link.classList.add("active-link");
    }
}
