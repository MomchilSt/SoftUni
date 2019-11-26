const template = x => `visited ${x} times`;

const links = {
  "Google": 2,
  "YouTube": 4,
  "SoftUni": 1,
  "stackoverflow": 6,
  "Gmail": 7,
  "Wikipedia": 4
}

document.addEventListener("click", (e) => {
  if (e.target && e.target.parentNode && e.target.classList.contains("linkCta")) {
    e.target.parentNode.querySelector(".linkOut")
      .innerHTML = template(links[e.target.textContent.trim()]++)
  }
})