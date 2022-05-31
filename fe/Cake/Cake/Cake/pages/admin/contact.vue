<template>
        <div class="contact_new container">
      <div class="row">
        <div class="col-12 col-md-4 mb-3 text-center"
              v-for="(contact,index) in listContacts"
                    :key="index">
            <ContactSummary 
                      :contact="contact"
                      />
        </div>
      </div>
    </div>
</template>

<script>
import ContactSummary from '@/components/Index/ContactSummary.vue'
import catalogApi from '@/api/catalogApi'
export default {
        layout: 'admin',
        components:{
            ContactSummary,
        },
        data(){
            return{
            listContacts:[
            ],
            }
        },

        async created(){
            await this.getAllContact() 
        },
        mounted(){},

        methods:{
            async getAllContact(){
                try{
                    const {data} = await catalogApi.getContact(this.$axios)
                    console.log(data)
                    this.listContacts = data
                }
                catch(err){
                    console.log(err)
                }
        }
    }
}
</script>
<style>

</style>