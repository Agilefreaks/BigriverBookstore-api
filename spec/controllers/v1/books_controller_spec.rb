require 'rails_helper'

RSpec.describe V1::BooksController do
  let!(:book1) { Book.create(title: 'Moby Dick') }

  describe 'GET #index' do
    before do
      get :index
    end

    it 'returns http success' do
      expect(response).to have_http_status(:success)
    end

    it 'renders expected books attributes' do
      json_response_data = JSON.parse(response.body)['data']
      book_attributes = %w(title isbn author image_url release_year description)
      expect(json_response_data.length).to eq 1
      expect(json_response_data.first['attributes'].keys).to match_array(book_attributes)
    end
  end

  describe 'GET #show' do
    before do
      get :show, params: { id: book1.id }
    end

    let(:expected_hash) do
      { 'title' => book1.title,
        'description' => book1.description,
        'image_url' => book1.image_url,
        'isbn' => book1.isbn,
        'release_year' => book1.release_year,
        'author' => book1.author }
    end

    it 'returns the book' do
      json_response_data = JSON.parse(response.body)['data']
      expect(response).to have_http_status(:success)
      expect(json_response_data['attributes']).to eq(expected_hash)
    end
  end
end
