<template>
    <div class="container">
      <div class="row">
        <div class="col-12 col-md-4 mb-3 text-center"
              v-for="(donhang,index) in listDonHang"
                    :key="index">
            <DonHangSummary 
                      :donhang="donhang"
                      />
        </div>
      </div>
    </div>
</template>

<script>
import catalogApi from '@/api/catalogApi'
import DonHangSummary from '@/components/Index/DonHangSummary.vue'
export default {
    layout: 'admin',
    components:{
        DonHangSummary
    },
    data(){
        return {
            listDonHang:[]
            }
    },
    async created(){
        await this.getDonHang()
    },
    methods:{
        async getDonHang(){
            try{
                const {data} = await catalogApi.getDonHang(this.$axios)
                console.log(data)
                this.listDonHang = data
            }
            catch(err){
                console.log("not gud")
            }
        }
    }
}
</script>