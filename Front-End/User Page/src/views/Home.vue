<script setup>
import { storeToRefs } from "pinia";

import { useAuthStore } from "@/stores";

const authStore = useAuthStore();
const { user } = storeToRefs(authStore);
</script>
<script>
import Bookings from "../components/BookingsComp.vue";
import Book from "../components/BookComp.vue";
import UpdateBook from "../components/BookUpComp.vue";
import BookSearch from "../components/BookSearchComp.vue";
import BookCancel from "../components/BookCanComp.vue";

const routes = {
  "/": Bookings,
  "/book": Book,
  "/upbook": UpdateBook,
  "/booksearch": BookSearch,
  "/bookcancel": BookCancel,
};

export default {
  data() {
    return {
      currentPath: window.location.hash,
    };
  },
  computed: {
    currentView() {
      return routes[this.currentPath.slice(1) || "/"] || NotFound;
    },
  },
  mounted() {
    window.addEventListener("hashchange", () => {
      this.currentPath = window.location.hash;
    });
  },
};
</script>

<template>
  <div id="app1">
    <component :is="currentView" />
  </div>
  <div class="container">
    <footer class="pt-4 my-md-5 pt-md-5 border-top">
      <div class="row">
        <div class="col-12 col-md">
          <img
            class="mb-2"
            src="https://img.icons8.com/office/256/5-star-hotel.png"
            alt=""
            width="24"
            height="24"
          />
          <small class="d-block mb-3 text-muted">&copy; 2023-2024</small>
        </div>
        <div class="col-6 col-md">
          <h5>Team</h5>
          <ul class="list-unstyled text-small">
            <li><a class="text-muted" href="#">Faizahamed</a></li>
            <li><a class="text-muted" href="#">Vishal</a></li>
            <li><a class="text-muted" href="#">Sirisha</a></li>
          </ul>
        </div>
        <div class="col-6 col-md">
          <h5>Project name</h5>
          <ul class="list-unstyled text-small">
            <li>
              <div class="col-12 col-md">
                <img
                  class="mb-2"
                  src="https://cdn-icons-png.flaticon.com/512/5627/5627109.png"
                  alt=""
                  width="48"
                  height="48"
                />
                <small class="d-block mb-3 text-muted"
                  >Hotel Reservation System</small
                >
              </div>
            </li>
          </ul>
        </div>
        <div class="col-6 col-md">
          <h5>About</h5>
          <ul class="list-unstyled text-small">
            <li><a class="text-muted" href="#">Locations</a></li>
            <li><a class="text-muted" href="#">Privacy</a></li>
            <li><a class="text-muted" href="#">Terms</a></li>
          </ul>
        </div>
      </div>
    </footer>
  </div>
</template>
<style>
.container {
  padding-top: 17vh;
}
</style>
