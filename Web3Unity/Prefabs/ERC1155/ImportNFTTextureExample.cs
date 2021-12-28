using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ImportNFTTextureExample : MonoBehaviour
{
    public class Response {
        public string image;
    }

    async void Start()
    {
        //string chain = "ethereum";
        //string network = "rinkeby";
        //string contract = "0x3a8A85A6122C92581f590444449Ca9e66D8e8F35";
        //string tokenId = "5";

        //// fetch uri from chain
        //string uri = await ERC1155.URI(chain, network, contract, tokenId);
        //print("uri: " + uri);

        //// fetch json from uri
        //UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        //await webRequest.SendWebRequest();
        //Response data = JsonUtility.FromJson<Response>(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));

        //// parse json to get image uri
        //string imageUri = data.image;
        //print("imageUri: " + imageUri);

        //// fetch image and display in game
        //UnityWebRequest textureRequest = UnityWebRequestTexture.GetTexture(imageUri);
        //await textureRequest.SendWebRequest();
        //this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)textureRequest.downloadHandler).texture;

        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://testnets-api.opensea.io/asset/0x88B48F654c30e99bc2e4A1559b4Dcf1aD93FA656/39976892780186851645799307649959543724358073583749944537417929763688875556865/"),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Debug.Log(body);
            var nft = JsonUtility.FromJson<NFTModel>(body);
            Debug.Log(nft.name);
            Debug.Log(nft.description);
            Debug.Log(nft.token_metadata);
        }
    }

    [Serializable]
    public class NFTModel
    {
        public string name;
        public string description;
        public string token_metadata;

    }

//"id":21885208,"token_id":"39976892780186851645799307649959543724358073583749944537417929763688875556865","num_sales":0,"background_color":null,"image_url":"https://lh3.googleusercontent.com/EoreMc3Gi4tijsunXmTQ0OpRgBV2ManOGNDAul4fPYhi5JIMirOM1WCFSBehKfjA-y_ghE_MI78gMObp6HUFdaEles2ontMjo19wzWs","image_preview_url":"https://lh3.googleusercontent.com/EoreMc3Gi4tijsunXmTQ0OpRgBV2ManOGNDAul4fPYhi5JIMirOM1WCFSBehKfjA-y_ghE_MI78gMObp6HUFdaEles2ontMjo19wzWs=s250","image_thumbnail_url":"https://lh3.googleusercontent.com/EoreMc3Gi4tijsunXmTQ0OpRgBV2ManOGNDAul4fPYhi5JIMirOM1WCFSBehKfjA-y_ghE_MI78gMObp6HUFdaEles2ontMjo19wzWs=s128","image_original_url":"https://ipfs.io/ipfs/bafybeiawvnurih2iv4aa36pix4qpmqfafwmfrccvzvcjb4d4omz23ob7ni/image","animation_url":"https://storage.opensea.io/files/f6a2489adb5d81cc350f798075475805.txt","animation_original_url":"https://ipfs.io/ipfs/bafybeiawvnurih2iv4aa36pix4qpmqfafwmfrccvzvcjb4d4omz23ob7ni/animation","name":"Face Model Test","description":"Test for creating and exporting NFT face model.","external_link":"https://www.veople.io/","asset_contract":{"address":"0x88b48f654c30e99bc2e4a1559b4dcf1ad93fa656","asset_contract_type":"semi-fungible","created_date":"2021-05-17T18:22:26.262750","name":"OpenSea Collections","nft_version":null,"opensea_version":"2.1.0","owner":676,"schema_name":"ERC1155","symbol":"OPENSTORE","total_supply":null,"description":null,"external_link":null,"image_url":null,"default_to_fiat":false,"dev_buyer_fee_basis_points":0,"dev_seller_fee_basis_points":0,"only_proxied_transfers":false,"opensea_buyer_fee_basis_points":0,"opensea_seller_fee_basis_points":250,"buyer_fee_basis_points":0,"seller_fee_basis_points":250,"payout_address":null},"permalink":"https://testnets.opensea.io/assets/0x88b48f654c30e99bc2e4a1559b4dcf1ad93fa656/39976892780186851645799307649959543724358073583749944537417929763688875556865","collection":{"payment_tokens":[{"id":382494,"symbol":"ETH","address":"0x0000000000000000000000000000000000000000","image_url":"https://storage.opensea.io/files/6f8e2979d428180222796ff4a33ab929.svg","name":null,"decimals":18,"eth_price":1.0,"usd_price":405.65},{ "id":180476,"symbol":"WETH","address":"0xc778417e063141139fce010982780140aa0cd5ab","image_url":"https://storage.opensea.io/files/accae6b6fb3888cbff27a013729c22dc.svg","name":"","decimals":18,"eth_price":1.0,"usd_price":3920.11},{ "id":1856879,"symbol":null,"address":"0xc778417e063141139fce010982780140aa0cd5ab","image_url":"","name":null,"decimals":18,"eth_price":null,"usd_price":null},{ "id":1857042,"symbol":null,"address":"0xc778417e063141139fce010982780140aa0cd5ab","image_url":"","name":null,"decimals":18,"eth_price":null,"usd_price":null}],"primary_asset_contracts":[],"traits":{ },"stats":{ "one_day_volume":0.0,"one_day_change":0.0,"one_day_sales":0.0,"one_day_average_price":0.0,"seven_day_volume":0.0,"seven_day_change":0.0,"seven_day_sales":0.0,"seven_day_average_price":0.0,"thirty_day_volume":0.0,"thirty_day_change":0.0,"thirty_day_sales":0.0,"thirty_day_average_price":0.0,"total_volume":0.0,"total_sales":0.0,"total_supply":1.0,"count":1.0,"num_owners":1,"average_price":0.0,"num_reports":0,"market_cap":0.0,"floor_price":0},"banner_image_url":null,"chat_url":null,"created_date":"2021-12-21T11:08:21.110851","default_to_fiat":false,"description":null,"dev_buyer_fee_basis_points":"0","dev_seller_fee_basis_points":"0","discord_url":null,"display_data":{ "card_display_style":"contain","images":[]},"external_url":null,"featured":false,"featured_image_url":null,"hidden":true,"safelist_request_status":"not_requested","image_url":null,"is_subject_to_whitelist":false,"large_image_url":null,"medium_username":null,"name":"Untitled Collection #4786112","only_proxied_transfers":false,"opensea_buyer_fee_basis_points":"0","opensea_seller_fee_basis_points":"250","payout_address":null,"require_email":false,"short_description":null,"slug":"untitled-collection-4786112","telegram_url":null,"twitter_username":null,"instagram_username":null,"wiki_url":null},"decimals":null,"token_metadata":"https://ipfs.io/ipfs/bafkreigz7lrtpbftc3wtzjl6jma6k47jc6zvmslu5uwqvpwrujnpkjwb7q","owner":{ "user":{ "username":"NullAddress"},"profile_img_url":"https://storage.googleapis.com/opensea-static/opensea-profile/1.png","address":"0x0000000000000000000000000000000000000000","config":""},"sell_orders":null,"creator":{ "user":{ "username":"AliNajjar"},"profile_img_url":"https://storage.googleapis.com/opensea-static/opensea-profile/15.png","address":"0x58621e95db3d730a4687a34be493fb552ee16af2","config":""},"traits":[],"last_sale":null,"top_bid":null,"listing_date":null,"is_presale":true,"transfer_fee_payment_token":null,"transfer_fee":null,"related_assets":[],"orders":[],"auctions":[],"supports_wyvern":true,"top_ownerships":[{"owner":{"user":{"username":"AliNajjar"},"profile_img_url":"https://storage.googleapis.com/opensea-static/opensea-profile/15.png","address":"0x58621e95db3d730a4687a34be493fb552ee16af2","config":""},"quantity":"1"}],"ownership":null,"highest_buyer_commitment":null}

    
}
