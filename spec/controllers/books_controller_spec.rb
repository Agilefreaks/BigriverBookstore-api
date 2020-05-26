# frozen_string_literal: true

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
      expect(json_response_data.length).to eq 1
      expect(json_response_data.first['attributes'].keys).to match_array(%w(title
                                                                            isbn
                                                                            author
                                                                            image_url
                                                                            release_year
                                                                            description))
    end
  end

  describe 'GET #show' do
    before do
      get :show, params: { id: book1.id }
    end

    it 'returns the book' do
      json_response_data = JSON.parse(response.body)['data']
      expect(response).to have_http_status(:success)
      expect(json_response_data['attributes']).to eq({ 'title' => book1.title,
                                                       'description' => book1.description,
                                                       'author' => book1.author,
                                                       'isbn' => book1.isbn,
                                                       'release_year' => book1.release_year,
                                                       'image_url' => book1.image_url })
    end
  end
end
