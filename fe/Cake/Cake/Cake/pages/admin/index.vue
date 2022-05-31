<template>
  <center><h1>XIN CHÀO ADMIN</h1></center>
</template>

<script>
export default {
  layout: 'admin',
  middleware: ['isAuthorize'],
}
</script>
