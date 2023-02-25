// Login main-page
const loginSectionEl = document.querySelector(".login-section");
const btnLogin = document.querySelector(".btn-login");
const mainContainer = document.querySelector(".main-container");

const closeModal = () => {
  if (loginSectionEl.classList.contains("element-showed")) {
    loginSectionEl.classList.remove("element-showed");
    loginSectionEl.classList.add("element-hidden");
  }
};

const openModal = () => {
  loginSectionEl.classList.add("element-showed");
  loginSectionEl.classList.remove("element-hidden");
};

btnLogin.addEventListener("click", openModal);

document.addEventListener("scroll", closeModal);

document.addEventListener("keydown", (e) => {
  if (e.key == "Escape") {
    closeModal();
  }
});
