<template>
    <div class="c-dashboard">
        <!-- <div class="c-dashboard__navitem">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 26 26" class="c-dashboard-navitem__svg">
            <path d="M16.563,15.9c-0.159-0.052-1.164-0.505-0.536-2.414h-0.009c1.637-1.686,2.888-4.399,2.888-7.07 c0-4.107-2.731-6.26-5.905-6.26c-3.176,0-5.892,2.152-5.892,6.26c0,2.682,1.244,5.406,2.891,7.088 c0.642,1.684-0.506,2.309-0.746,2.396C5.93,17.103,2.03,19.294,2.03,21.457c0,0.584,0,0.23,0,0.811 c0,2.947,5.714,3.617,11.002,3.617c5.296,0,10.938-0.67,10.938-3.617c0-0.58,0-0.227,0-0.811 C23.97,19.229,20.051,17.055,16.563,15.9z"/>
            </svg>
        </div> -->
        <div class="c-dashboard__navitem">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" class="c-dashboard-navitem__svg">
                <path d="M 3 1 L 3 2 L 2.5 2 C 1.6774686 2 1 2.6774686 1 3.5 L 1 12.5 C 1 13.322531 1.6774686 14 2.5 14 L 12.5 14 C 13.322531 14 14 13.322531 14 12.5 L 14 3.5 C 14 2.6774686 13.322531 2 12.5 2 L 12 2 L 12 1 L 11 1 L 11 2 L 4 2 L 4 1 L 3 1 z M 2.5 3 L 3 3 L 3 4 L 4 4 L 4 3 L 11 3 L 11 4 L 12 4 L 12 3 L 12.5 3 C 12.781469 3 13 3.2185314 13 3.5 L 13 5 L 2 5 L 2 3.5 C 2 3.2185314 2.2185314 3 2.5 3 z M 2 6 L 13 6 L 13 12.5 C 13 12.781469 12.781469 13 12.5 13 L 2.5 13 C 2.2185314 13 2 12.781469 2 12.5 L 2 6 z M 5 7 L 5 8 L 6 8 L 6 7 L 5 7 z M 7 7 L 7 8 L 8 8 L 8 7 L 7 7 z M 9 7 L 9 8 L 10 8 L 10 7 L 9 7 z M 11 7 L 11 8 L 12 8 L 12 7 L 11 7 z M 3 9 L 3 10 L 4 10 L 4 9 L 3 9 z M 5 9 L 5 10 L 6 10 L 6 9 L 5 9 z M 7 9 L 7 10 L 8 10 L 8 9 L 7 9 z M 9 9 L 9 10 L 10 10 L 10 9 L 9 9 z M 11 9 L 11 10 L 12 10 L 12 9 L 11 9 z M 3 11 L 3 12 L 4 12 L 4 11 L 3 11 z M 5 11 L 5 12 L 6 12 L 6 11 L 5 11 z M 7 11 L 7 12 L 8 12 L 8 11 L 7 11 z"/>
            </svg>
        </div>
        <div class="c-dashboard__navitem">
            <svg version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
            viewBox="0 0 16 16" style="enable-background:new 0 0 16 16;" xml:space="preserve" class="c-dashboard-navitem__svg">
                <path d="M3,1v1H2.5C1.7,2,1,2.7,1,3.5v9C1,13.3,1.7,14,2.5,14h10c0.8,0,1.5-0.7,1.5-1.5v-9C14,2.7,13.3,2,12.5,2H12V1h-1v1H4V1H3z
        M2.5,3H3v1h1V3h7v1h1V3h0.5C12.8,3,13,3.2,13,3.5V5H2V3.5C2,3.2,2.2,3,2.5,3z M2,6h11v6.5c0,0.3-0.2,0.5-0.5,0.5h-10
        C2.2,13,2,12.8,2,12.5V6z M8.1,11.5H6.9V7.2h1.3V11.5z M5.3,10V8.7h4.3V10H5.3z"/>
                <path class="st0" d="M2.7,6.6"/>
            </svg>
        </div>
        <div class="c-dashboard__navitem">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 16 16" class="c-dashboard-navitem__svg">
                <path d="M 2.5 1 C 1.6774686 1 1 1.6774686 1 2.5 L 1 12.5 C 1 13.322531 1.6774686 14 2.5 14 L 12.5 14 C 13.322531 14 14 13.322531 14 12.5 L 14 12 L 14 11 L 14 10 L 13 11 L 13 12 L 13 12.5 C 13 12.781469 12.781469 13 12.5 13 L 2.5 13 C 2.2185314 13 2 12.781469 2 12.5 L 2 2.5 C 2 2.2185314 2.2185314 2 2.5 2 L 12.5 2 C 12.781469 2 13 2.2185314 13 2.5 L 13 4 L 14 5 L 14 3 L 14 2.5 C 14 1.6774686 13.322531 1 12.5 1 L 2.5 1 z M 10.728516 4.0214844 L 10.021484 4.7285156 L 12.292969 7 L 5 7 L 5 8 L 12.292969 8 L 10.021484 10.271484 L 10.728516 10.978516 L 14.207031 7.5 L 10.728516 4.0214844 z" font-weight="400" font-family="sans-serif" white-space="normal" overflow="visible"/>
            </svg>
        </div>

    </div>
</template>

<script>
export default {
    
}
</script>

<style lang="scss" scoped>
</style>

<style lang="scss" scoped>
@import '../style/components/components.dashboard';
</style>
