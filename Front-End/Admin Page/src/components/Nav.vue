<script setup>
import { storeToRefs } from "pinia";

import { useAuthStore } from "@/stores";

const authStore = useAuthStore();
const { user } = storeToRefs(authStore);
</script>

<template>
  <nav v-show="authStore.user">
    <div
      class="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom box-shadow"
    >
      <h5 class="my-0 mr-md-auto font-weight-normal" v-if="user">
        <b>{{ user.firstName }}'s</b> Dashboard
      </h5>
      <nav class="my-2 my-md-0 mr-md-3">
        <a class="p-2 text-dark" href="#/">Hotels</a>
        <a class="p-2 text-dark" href="#/addhotel">Add Hotel</a>
        <a class="p-2 text-dark" href="#/updhotel">Update Hotel</a>
        <a class="p-2 text-dark" href="#/hotelsearch">Search</a>
        <a class="p-2 text-dark" href="#/hotelcancel">Delete Hotel</a>
        <!-- "/": Hotels,
  "/addhotel": Hotel,
  "/updhotel": UpdateHotel,
  "/hotelsearch": HotelSearch,
  "/hotelcancel": HotelCancel, -->
      </nav>
      <router-link to="/users" class="btn btn-primary">Users</router-link>
      &nbsp;
      <a class="btn btn-outline-primary" @click="authStore.logout()">Log out</a>
    </div>
  </nav>
</template>
