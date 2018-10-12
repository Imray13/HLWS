# A service to share and find promocodes

## Promocode entity:
	Id  
	Description  
	Code  
	PublisherId  
	ExpireDate  
	IsActive  
	Rating  

## Publisher entity:
	Id  
	Name  
	Description  


## API

/codes/all GET  
/codes/{id} GET  
/codes/add POST  
/codes/{id}/edit PATCH  
/codes/{id}/delete DELETE  
/codes/{id}/archive POST  
/codes/{id}/rate POST  


/publishers/add POST  
/publishers/{id} GET  
/publishers/all GET  
/publishers/{id}/edit PATCH  
/publishers/{id}/delete DELETE  
/publishers/{id}/codes GET  
/publishers/find?q={query} GET  