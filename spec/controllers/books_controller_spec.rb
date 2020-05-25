require "rails_helper"

RSpec.describe V1::BooksController do
  let! (:book1) { Book.create(title: 'Moby Dick') }

  describe "GET #index" do
    before do
      get :index
    end
    it "returns http success" do
      expect(response).to have_http_status(:success)
    end
    it "renders expected books attributes" do
      json_response_data = JSON.parse(response.body)['data']
      expect(json_response_data.first['attributes'].keys).to match_array(['title',
                                                                          'isbn',
                                                                          'author',
                                                                          'image_url', 
                                                                          'release_year'])
    end
  end
end