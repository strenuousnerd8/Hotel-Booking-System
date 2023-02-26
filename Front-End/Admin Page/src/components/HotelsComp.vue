<script>
export default {
  data() {
    return {
      post: [],
    };
  },
  methods: {
    async getPosts() {
      fetch("https://localhost:7225/api/Admin")
        .then((response) => response.json())
        .then((data) => (this.post = data));
    },
  },
};
</script>

<template>
  <h1 align="left">Hotels</h1>
  <div id="app1" class="table-responsive">
    <button @click="getPosts">Show Hotels</button>
    <hr />
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">Hotel id</th>
          <th>Hotel name</th>
          <th>Location</th>
          <th>Room type</th>
          <th>Complimentary Food</th>
          <th>Prices</th>
        </tr>
      </thead>
      <tbody>
        <template v-if="post.length">
          <tr v-for="p in post" :key="p.id">
            <th scope="row">{{ p.id }}</th>
            <td>{{ p.hotelName }}</td>
            <td>{{ p.location }}</td>
            <td>{{ p.roomTypes }}</td>
            <td v-if="p.complimentaryFood">Yes</td>
            <td v-else>No</td>
            <td>{{ p.prices }}</td>
          </tr>
        </template>
      </tbody>
    </table>
  </div>
</template>

<style>
#app1 {
  text-align: center;
  margin: 0;
  padding: 0;
}

.table {
  text-align: left;
}
</style>
